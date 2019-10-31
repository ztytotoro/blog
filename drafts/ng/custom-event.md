# Custom Event

## Imports

```ts
import { Output, EventEmitter } from '@angular/core';
```

## Declare property

```ts
@Output()
onSomeEvent = new EventEmitter<T>();
```

## Send event

```ts
this.onSomeEvent.emit(...)
```

## Listten

```html
<... (onSomeEvent)="handle($event)" ...>
```
