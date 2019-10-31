# Deep clone object

```ts
function clone(obj: number | string | object | boolean | Array<any> | Date) {
  if (obj instanceof Date) {
    return new Date(obj.getTime());
  }
  if (typeof obj === 'object') {
    return JSON.parse(JSON.stringify(obj));
  }
  return obj.valueOf();
}
```
