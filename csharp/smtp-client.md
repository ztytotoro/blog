---
tags:
  - c#
  - .net
---

# C# 中使用 SmtpClient

## 引用

```cs
using System.Net.Mail;
```

## 步骤

1. 构造发件人

   - `address - 邮件地址`
   - `displayName - 显示名称`

   ```cs
   var from = new MailAddress(address, displayName);
   ```

2. 构造收件人

   - `address - 邮件地址`
   - `displayName - 显示名称`

   ```cs
   var to = new MailAddress(address, displayName);
   ```

3. Message

   ```cs
   var message = new MailMessage(from, to);
   ```

   - CC (optional)
     ```cs
     message.CC.Add(address);
     ```

4. SMPT Client

   - `host - smpt 服务器地址`

   ```cs
   var client = new SmtpClient(host);
   ```

5. 发送邮件

   ```cs
   client.Send(message);
   ```
