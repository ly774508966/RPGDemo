#if !BESTHTTP_DISABLE_ALTERNATE_SSL

using System;

namespace Org.BouncyCastle.Security.Certificates
{
#if !(NETCF_1_0 || NETCF_2_0 || SILVERLIGHT || NETFX_CORE)
    [Serializable]
#endif
    public class CertificateNotYetValidException : CertificateException
	{
		public CertificateNotYetValidException() : base() { }
		public CertificateNotYetValidException(string message) : base(message) { }
		public CertificateNotYetValidException(string message, Exception exception) : base(message, exception) { }
	}
}

#endif
