---
title: Git Worktree
---

在某些场景下，我们需要创建新的分支来更新项目所依赖的包，如果项目长时间没有更新过，往往不能在短时间内完成这项任务，从而需要在开发分支之间切换，但是这时候本地安装的包就会出现冲突，比如 node.js 的 node_modules

git worktree 给了我们一种可能，可以想同一个仓库的不同分支存在与两个不同的目录，从而维护各自的本地包

### 查看所有目录

```sh
git worktree list
```

### 新建目录

`$path` 为文件目录， 可使用相对路径，`$branch`为分支名称

```sh
git worktree add $path $branch
```
