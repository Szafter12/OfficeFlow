using FluentValidation;
using OfficeFlow.DTOs.Reservation;

public class ReservationDtoValidator : AbstractValidator<ReservationDto>
{
    public ReservationDtoValidator()
    {
        RuleFor(x => x.userId).NotEmpty().WithMessage("User ID is required");

        RuleFor(x => x.deskId).GreaterThan(0).WithMessage("Select correct desk");

        RuleFor(x => x.startDate)
            .NotEmpty()
            .GreaterThanOrEqualTo(DateTime.Today)
            .WithMessage("Reservation cant be made in past");

        RuleFor(x => x.endDate)
            .NotEmpty()
            .GreaterThan(x => x.startDate)
            .WithMessage("End date must be greater than start date");
    }
}
