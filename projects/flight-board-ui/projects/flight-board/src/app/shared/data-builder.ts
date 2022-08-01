import { ObjectBuilderBase } from 'ts-object-builder/dist/object-builder';

class DataBuilderBase<T, K extends keyof T> extends ObjectBuilderBase<T, K> {
    constructor(creator: new (arg?: any) => T = Object as any) {
        super(creator);
    }

    /**
     * Overrides current object with a partial object
     * @param props
     */
    public assign<KType extends K>(props: Partial<T>) {
        const keys = <Array<KType>>Object.keys(props);
        keys.forEach(key => super.with(key, props[key]!));
        return this;
    }
}

export class DataBuilder<T> extends DataBuilderBase<T, keyof T> {}
