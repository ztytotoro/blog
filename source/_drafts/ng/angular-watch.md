---
title: Watch changes in anglar(2+)
---

```ts
import { DoCheck, KeyValueDiffers, KeyValueDiffer } from '@angular/core';

differ: KeyValueDiffer<string, any>;
constructor(private differs: KeyValueDiffers) {
  this.differ = this.differs.find({}).create();
}

ngDoCheck() {
  const change = this.differ.diff(this);
  if (change) {
    change.forEachChangedItem(item => {
      console.log('item changed', item);
    });
  }
}
```
