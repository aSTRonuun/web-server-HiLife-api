using AutoMapper;
using HiLife_API.Configurations;
using HiLife_API.Data.ValueObjects;
using HiLife_API.Model;
using HiLife_API.Repository;
using HiLife_API.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HiLife_API.Business.Implementations;

public class LoginBusiness : ILoginBusiness
{
    private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
    private TokenConfiguration _configuration;

    private IPatientRepository _repository;
    private readonly ITokenService _tokenService;
    private IMapper _mapper;

    public LoginBusiness(TokenConfiguration configuration, IPatientRepository repository, ITokenService tokenService, IMapper mapper)
    {
        _configuration = configuration;
        _repository = repository;
        _tokenService = tokenService;
        _mapper = mapper;
    }

    public TokenVO ValidateCredentials(PatientVO userCredentials)
    {
        var credentials = _mapper.Map<Patient>(userCredentials);
        var user = _repository.ValidateCredentials(credentials);
        if (user == null) return null;

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.Result.Email)
        };

        var acessToken = _tokenService.GenerateAccessToken(claims);
        var refreshToken = _tokenService.GenerateRefreshToken();

        user.Result.RefreshToken = refreshToken;
        user.Result.RefreshTokenExperyTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);

        _repository.RefreshUserInfo(user.Result);

        DateTime createDate = DateTime.Now;
        DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

        return new TokenVO(
            true,
            createDate.ToString(DATE_FORMAT),
            expirationDate.ToString(DATE_FORMAT),
            acessToken,
            refreshToken
            );
    }

    public TokenVO CreateCredentials(PatientVO patient)
    {
        var patientCredetials = _mapper.Map<Patient>(patient);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
            new Claim(JwtRegisteredClaimNames.UniqueName, patientCredetials.Email)
        };

        var acessToken = _tokenService.GenerateAccessToken(claims);
        var refreshToken = _tokenService.GenerateRefreshToken();

        patientCredetials.RefreshToken = refreshToken;
        patientCredetials.RefreshTokenExperyTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);

        _repository.Create(patientCredetials);

        DateTime createDate = DateTime.Now;
        DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

        return new TokenVO(
            true,
            createDate.ToString(DATE_FORMAT),
            expirationDate.ToString(DATE_FORMAT),
            acessToken,
            refreshToken
            );

    }

    public bool RovokeToken(string userName)
    {
        throw new NotImplementedException();
    }


}
