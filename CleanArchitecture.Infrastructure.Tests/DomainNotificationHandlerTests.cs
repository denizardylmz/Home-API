﻿using CleanArchitecture.Domain.Notifications;
using FluentAssertions;
using Xunit;

namespace CleanArchitecture.Infrastructure.Tests;

public sealed class DomainNotificationHandlerTests
{
    [Fact]
    public void Should_Create_DomainNotificationHandler_Instance()
    {
        var domainNotificationHandler = new DomainNotificationHandler();
        domainNotificationHandler.GetNotifications().Should().BeEmpty();
    }

    [Fact]
    public void Should_Handle_DomainNotification()
    {
        string key = "Key";
        string value = "Value";
        string code = "Code";

        var domainNotification = new DomainNotification(key, value, code);
        var domainNotificationHandler = new DomainNotificationHandler();
        domainNotificationHandler.Handle(domainNotification);
        domainNotificationHandler.GetNotifications().Should().HaveCount(1);
    }

    [Fact]
    public void Should_Handle_DomainNotification_Overload()
    {
        string key = "Key";
        string value = "Value";
        string code = "Code";

        var domainNotification = new DomainNotification(key, value, code);
        var domainNotificationHandler = new DomainNotificationHandler();
        domainNotificationHandler.Handle(domainNotification, default);
        domainNotificationHandler.GetNotifications().Should().HaveCount(1);
    }

    [Fact]
    public void DomainNotification_HasNotifications_After_Handling_One()
    {
        string key = "Key";
        string value = "Value";
        string code = "Code";

        var domainNotification = new DomainNotification(key, value, code);
        var domainNotificationHandler = new DomainNotificationHandler();
        domainNotificationHandler.Handle(domainNotification);

        domainNotificationHandler.HasNotifications().Should().BeTrue();
    }

    [Fact]
    public void DomainNotification_HasNotifications_False_Not_Handling_One()
    {
        var domainNotificationHandler = new DomainNotificationHandler();

        domainNotificationHandler.HasNotifications().Should().BeFalse();
    }
}
