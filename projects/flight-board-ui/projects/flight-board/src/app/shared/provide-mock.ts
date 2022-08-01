import { InjectionToken, Provider, Type } from '@angular/core';

export type Mock<T> = T & { [P in keyof T]: T[P] extends Function ? T[P] & jasmine.Spy : T[P] };
export type MockInitialValues<T> = { [K: string]: any };

function createMock<T>(type: Type<T>, initialValues?: MockInitialValues<T>): Mock<T> {
    const target: any = {};

    function installProtoMethods(proto: any) {
        if (proto === null || proto === Object.prototype) {
            return;
        }

        for (const key of Object.getOwnPropertyNames(proto)) {
            // tslint:disable-next-line: no-non-null-assertion
            const descriptor = Object.getOwnPropertyDescriptor(proto, key)!;

            if (typeof descriptor.value === 'function' && key !== 'constructor') {
                target[key] = jasmine.createSpy(key);

                if (initialValues && initialValues[key]!) {
                    target[key].and.returnValue(initialValues[key]!);
                }
            } else if (
                typeof descriptor.get === 'function' ||
                typeof descriptor.set === 'function'
            ) {
                // pass through get/set so they can be spied on manually
                Object.defineProperty(target, key, descriptor);
            }
        }

        installProtoMethods(Object.getPrototypeOf(proto));
    }

    installProtoMethods(type.prototype);

    return target;
}

export interface MockConfig<T> {
    initialValues?: MockInitialValues<Partial<T>>;
}

export function provideMock<T>(
    type: Type<T>,
    config?: MockConfig<T>,
    token?: InjectionToken<T>,
): Provider {
    return {
        provide: token || type,
        useFactory: () => createMock(type, config?.initialValues),
    };
}
