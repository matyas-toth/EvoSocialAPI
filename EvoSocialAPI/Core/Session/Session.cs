using EvoSocialAPI.Core.Account;
using EvoSocialAPI.Core.Utils;

namespace EvoSocialAPI.Core.Session
{
    public class Session
    {

        public AccountIdentifier Account;

        public Session(AccountIdentifier account) {

            this.Account = account;

        }

        public SessionIdentifier Start()
        {
            return AccountUtils.StartSession(Account.GetToken());
        }

    }
}
