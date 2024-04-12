﻿namespace LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.DTO
{
    public record DocumentTypeResponse
    {
        public int DocumentTypeId { get; init; }
        public string DocumentTypeDescription { get; init; }
        public bool Active { get; init; }

    }
}