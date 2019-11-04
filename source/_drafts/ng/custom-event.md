---
title: Custom Event
---

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

## Listen Event

```html
<... (onSomeEvent)="handle($event)" ...>
```
