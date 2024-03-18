using System.ComponentModel.DataAnnotations;
using Tcc.Identity.Core.Common;

namespace Tcc.Identity.Core.Entities
{
    public class User : BaseEntity
    {        /// <summary>
             /// Gets or sets the user name for this user.
             /// </summary>
        [StringLength(256)]
        public virtual string UserName { get; set; }

        /// <summary>
        /// Gets or sets the email address for this user.
        /// </summary>
        [StringLength(256)]
        public virtual string Email { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if a user has confirmed their email address.
        /// </summary>
        /// <value>True if the email address has been confirmed, otherwise false.</value>
        public virtual bool EmailConfirmed { get; set; }

        /// <summary>
        /// Gets or sets a salted and hashed representation of the password for this user.
        /// </summary>
        public virtual string? PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets a first name of user.
        /// </summary>
        /// <value>True if the email address has been confirmed, otherwise false.</value>
        [StringLength(256)]
        public virtual string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets a last name of user.
        /// </summary>
        /// <value>True if the email address has been confirmed, otherwise false.</value>
        [StringLength(256)]
        public virtual string? LastName { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if two factor authentication is enabled for this user.
        /// </summary>
        /// <value>True if 2fa is enabled, otherwise false.</value>
        public virtual bool TwoFactorEnabled { get; set; }

        /// <summary>
        /// Gets or sets the date and time, in UTC, when any user lockout ends.
        /// </summary>
        /// <remarks>
        /// A value in the past means the user is not locked out.
        /// </remarks>
        public virtual DateTimeOffset? LockoutEnd { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if the user could be locked out.
        /// </summary>
        /// <value>True if the user could be locked out, otherwise false.</value>
        public virtual bool LockoutEnabled { get; set; }

        /// <summary>
        /// Gets or sets the number of failed login attempts for the current user.
        /// </summary>
        public virtual int AccessFailedCount { get; set; }

        /// <summary>
        /// Gets or sets reset password code
        /// </summary>
        [StringLength(256)]
        public virtual string? ResetPwCode { get; set; }

        /// <summary>
        /// Gets or sets reset password code expiration time
        /// </summary>
        public virtual DateTimeOffset? ResetPwCodeExpireTime { get; set; }

        /// <summary>
        /// Returns the username for this user.
        /// </summary>
        public override string? ToString()
            => UserName;
    }
}
