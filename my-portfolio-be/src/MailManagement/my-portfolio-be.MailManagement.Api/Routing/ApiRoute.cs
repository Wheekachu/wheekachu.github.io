using my_portfolio_be.Shared.Routing;

namespace my_portfolio_be.MailManagement.Api.Routing;

public static class ApiRoute
{
    private const string Base = "mail-management";

    public const string EmailSender = $"{ApiBaseRoute.ApiBase}/{Base}/email-sender";
}
