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

1. 发件人

   ```cs
   var from = new MailAddress(address, displayName);
   ```

2. 收件人

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

   ```cs
   var client = new SmtpClient(host);
   ```

5. 发送邮件

   ```cs
   client.Send(message);
   ```
