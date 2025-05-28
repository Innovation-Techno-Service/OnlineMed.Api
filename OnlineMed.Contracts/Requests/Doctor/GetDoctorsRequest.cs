using OnlineMed.Domain.Enums;

namespace OnlineMed.Contracts.Requests.Doctor;

public sealed record GetDoctorsRequest(
    string? SearchTerm,
    decimal? MinExperience,
    decimal? MaxExperience,
    decimal? MinAge,
    decimal? MaxAge,
    decimal? MinPrice,
    decimal? MaxPrice,
    decimal? MinRating,
    decimal? MaxRating,
    Gender? Gender);
