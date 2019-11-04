---
title: C# 中使用 SmtpClient
tags:
  - c#
  - .net
---

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

3. SMPT Client

   - `host - smpt 服务器地址`

   ```cs
   using(var client = new SmtpClient()) {
     //...
     client.Host = host;
     //...
   }
   ```

4. 登陆授权

   - `client - SmtpClient(in setp 4)`
   - `userName - 登陆用户名，一般与发件人邮箱相同`
   - `password - 密码`

   ```cs
   var basicCredential = new System.Net.NetworkCredential(userName, password);
   client.UseDefaultCredentials = false;
   client.Credentials = basicCredential;
   ```

5. 构造 Message

   - `body: string - 邮件内容`
   - `subject - 邮件主题`

   ```cs
   using(var message = new MailMessage(from, to)) {
     message.Body = body;
     message.BodyEncoding = System.Text.Encoding.UTF8;

     message.Subject = subject;
     message.SubjectEncoding = System.Text.Encoding.UTF8;

     // 如果邮件包含html内容，加上这一行
     message.IsBodyHtml = true;
   }
   ```

   - CC (optional)
     ```cs
     message.CC.Add(address);
     ```

6. 发送邮件
   - `client - SmtpClient(in setp 4)`
   - `message - MailMessage(in setp 5)`
   ```cs
   try
   {
       client.Send(message);
   }
   catch (SmtpException ex)
   {
       throw ex;
   }
   ```

## 完整示例

- `$`开头的变量为外部传入变量

```cs
var from = new MailAddress($fromAddress, $fromDisplayName);

var to = new MailAddress($toAddress, $toDisplayName);

using(var client = new SmtpClient()) {
  client.Host = $host;
  var basicCredential = new System.Net.NetworkCredential(userName, password);
  client.UseDefaultCredentials = false;
  client.Credentials = basicCredential;

  using(var message = new MailMessage(from, to)) {
    message.Body = $body;
    message.BodyEncoding = System.Text.Encoding.UTF8;

    message.Subject = $subject;
    message.SubjectEncoding = System.Text.Encoding.UTF8;

    // 如果邮件包含html内容，加上这一行
    message.IsBodyHtml = true;

    // 可选
    message.CC.Add(ccAddress);

    try
    {
        client.Send(message);
    }
    catch (SmtpException ex)
    {
        // 处理异常
    }
  }
}
```

## 生产环境示例

[GitHub 仓库](https://github.com/ztytotoro/blog/tree/master/samples/csharp/smtp-client)
