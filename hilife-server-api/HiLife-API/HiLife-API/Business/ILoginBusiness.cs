using HiLife_API.Data.ValueObjects;

namespace HiLife_API.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(PatientVO patient);

        TokenVO CreateCredentials(PatientVO patient);

        bool RovokeToken(string userName);
    }
}
