using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Web.Http.SelfHost;
using System.Web.Http.SelfHost.Channels;
using System.ServiceModel;

namespace WebApiSelfHostAplication
{
    public class MyConfig : HttpSelfHostConfiguration
    {

        public MyConfig(string name) : base(name)
        {

        }

        protected override System.ServiceModel.Channels.BindingParameterCollection OnConfigureBinding(System.Web.Http.SelfHost.Channels.HttpBinding httpBinding)
        {
            httpBinding.Security.Mode = HttpBindingSecurityMode.TransportCredentialOnly;
            httpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;
            return base.OnConfigureBinding(httpBinding);
        }

    }
}
