# 📧 MasterEmailPaperCut

This project demonstrates how to integrate **FluentEmail** with **Papercut SMTP** in an ASP.NET Core application

## 🚀 Project Overview

The project provides an API endpoint to send emails using **FluentEmail** and a local SMTP server (e.g., **Papercut**). It leverages ASP.NET Core's Dependency Injection to configure and manage the email services.

## 🛠️ Technologies Used

- **ASP.NET Core**
- **FluentEmail** (for email composition and delivery)
- **Papercut SMTP** (for local email testing)
- **Dependency Injection**

## 📂 Project Structure

- **Program.cs**: Configures services and sets up FluentEmail with SMTP settings.
- **EmailController.cs**: API controller to handle email sending.
- **appsettings.json**: Configuration file for SMTP settings.

## ⚙️ Configuration

Update the `appsettings.json` file with your SMTP settings:

```json
"SmtpSettings": {
  "Host": "localhost",
  "Port": 25,
  "FromEmail": "noreply@example.com",
  "FromName": "Example Service"
}
```

## 📝 Code Highlights

### Program.cs

```csharp
var smtpSettings = builder.Configuration.GetSection("SmtpSettings");
builder.Services.AddFluentEmail(smtpSettings["FromEmail"], smtpSettings["FromName"])
    .AddSmtpSender(smtpSettings["Host"], smtpSettings.GetValue<int>("Port"));
```

### EmailController.cs

```csharp
[HttpPost("send")]
public async Task<IActionResult> SendEmail(SendEmail email)
{
    SendResponse response = await _emailService
        .To(email.ToEmail)
        .Subject(email.Subject)
        .Body(email.Message)
        .SendAsync();
    
    return response.Successful ? Ok(response) : BadRequest(response);
}
```

## 📬 Testing the API

1. Run the application.
2. Use tools like **Postman** or **cURL** to send a POST request:

```http
POST /api/email/send
Content-Type: application/json

{
  "ToEmail": "test@example.com",
  "Subject": "Test Email",
  "Message": "Hello earthlings!"
}
```

3. Verify the email in **Papercut**.

## 🧠 Key Concepts

- **Dependency Injection**: Services are injected into the `EmailController` using ASP.NET Core's DI container.
- **FluentEmail**: Provides an easy-to-use API for email composition.
- **Papercut SMTP**: Acts as a local SMTP server for email testing.

## ✅ Next Steps

- Enhance error handling in email sending.
- Add logging for email delivery status.
- Integrate a production-ready SMTP server.

## 🤝 Contributing
Feel free to submit issues or pull requests!

## 📄 License
This project is licensed under the **MIT License**.
