using System;

namespace CleanArchitecture.Domain.Commands.Tenants.UpdateTenant;

public sealed class UpdateTenantCommand : CommandBase
{
    private static readonly UpdateTenantCommandValidation s_validation = new();

    public UpdateTenantCommand(Guid tenantId, string name) : base(tenantId)
    {
        Name = name;
    }

    public string Name { get; }

    public override bool IsValid()
    {
        ValidationResult = s_validation.Validate(this);
        return ValidationResult.IsValid;
    }
}