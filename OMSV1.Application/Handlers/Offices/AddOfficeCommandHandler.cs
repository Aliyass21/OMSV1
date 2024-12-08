﻿using MediatR;
using OMSV1.Application.Commands.Offices;
using OMSV1.Domain.Entities.Offices;
using OMSV1.Domain.SeedWork;
using System.Threading;
using System.Threading.Tasks;

namespace OMSV1.Application.Handlers.Offices
{
    public class AddOfficeCommandHandler(IGenericRepository<Office> repository) : IRequestHandler<AddOfficeCommand, int>
    {
        private readonly IGenericRepository<Office> _repository = repository;

        public async Task<int> Handle(AddOfficeCommand request, CancellationToken cancellationToken)
        {
            // Create a new Office using the constructor
            var office = new Office(
                request.Name,
                request.Code,
                request.ReceivingStaff,
                request.AccountStaff,
                request.PrintingStaff,
                request.QualityStaff,
                request.DeliveryStaff,
                request.GovernorateId
            );

            // Add the Office to the repository
            await _repository.AddAsync(office);
            return office.Id; // Assuming the ID is generated by the database
        }
    }
}
