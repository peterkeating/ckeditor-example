using System;
using MvcTurbine.ComponentModel;
using CKEditorExample.Core.Provider;
using CKEditorExample.Core.Service;
using CKEditorExample.Core.Security;
using System.Web;
using System.Web.Security;

namespace CKEditorExample.Infrastructure
{
    public class DefaultRegistration : IServiceRegistration
    {
        public void Register(IServiceLocator locator)
        {
            locator.Register<IUserService, UserService>();
            locator.Register<IDatabaseProvider, MongoDatabaseProvider>();
            locator.Register<IEncryption, Encryption>();
            locator.Register<ISessionAuthentication, SessionAuthentication>();
            locator.Register<IHttpContextProvider, HttpContextProvider>();
        }
    }
}