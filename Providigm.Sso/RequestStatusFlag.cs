namespace Providigm.Sso
{
    /// <summary>
    /// Error Code
    /// 0x00 - OK
    /// 0x01 - No Auth
    /// 0x02 - Bad IP
    /// 0x03 - Unknown Error
    /// 0x04 - Duplicate Email Address
    /// 0x05 - Invalid EMail Address
    /// 0x06 - Invalid User SSO ID
    /// 0x07 - Invalid CSE Type
    /// 0x08 - Invalid CSE ID
    /// 0x09 - Invalid Role Number
    /// 0x0A - Invalid Token Time Specified
    /// </summary>
    public enum RequestStatusFlag
    {
        Undefined,
        Ok,
        NoAuth,
        BadIp,
        UnknownError,
        DuplicateEmailAddress,
        InvalidEmailAddress,
        InvalidUserSsoId,
        InvalidCseType,
        InvalidCseId,
        InvalidRoleNumber,
        InvalidTokenTime
    }
}