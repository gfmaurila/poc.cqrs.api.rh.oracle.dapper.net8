﻿using poc.core.api.net8;
using poc.core.api.net8.api.net8.api.net8.Abstractions;
using Poc.Domain.Entities.Region.Events;

namespace Poc.Domain.Entities.Region;
public class RegionEntity : BaseEOraclentity, IAggregateRoot
{
    public decimal RegionId { get; private set; }
    public string RegionName { get; private set; }

    public RegionEntity()
    {
    }

    public RegionEntity(string regionName)
    {
        RegionName = regionName;
        AddDomainEvent(new RegionCreatedEvent(RegionId, RegionName));
    }

    public RegionEntity(decimal regionId, string regionName)
    {
        RegionId = regionId;
        RegionName = regionName;
        AddDomainEvent(new RegionUpdateEvent(RegionId, RegionName));
    }

    public RegionEntity(decimal regionId)
    {
        RegionId = regionId;
        AddDomainEvent(new RegionDeleteEvent(RegionId, RegionName));
    }

    // Este método permitirá definir o RegionId após a entidade ser criada.
    public void SetRegionId(decimal regionId)
    {
        if (RegionId == default)
        {
            RegionId = regionId;
        }
        else
        {
            throw new InvalidOperationException("O ID só pode ser definido uma vez.");
        }
    }
}

