﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ordering.Application.Contracts.Infrastructure;
using Ordering.Application.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Ordering.Infrastructure.Mail;

public class EmailService : IEmailService
{

    public EmailSettings EmailSettings { get; }
    public ILogger<EmailService> Logger { get; }

    public EmailService(IOptions<EmailSettings> emailSettings, ILogger<EmailService> logger)
    {
        EmailSettings = emailSettings.Value;
        Logger = logger;
    }

    public async Task<bool> SendEmail(Email email)
    {
        var client = new SendGridClient(EmailSettings.ApiKey);
        var subject = email.Subject;
        var to = new EmailAddress(email.To);
        var emailBody = email.Body;
        var from = new EmailAddress
        {
            Email = EmailSettings.FromAddress,
            Name = EmailSettings.FromName
        };

        var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
        var response = await client.SendEmailAsync(sendGridMessage);

        Logger.LogInformation("Email Sent");

        if (response.StatusCode == System.Net.HttpStatusCode.Accepted ||
            response.StatusCode == System.Net.HttpStatusCode.OK)
            return true;

        Logger.LogInformation("Email Sending Failed");

        return false;
    }
}