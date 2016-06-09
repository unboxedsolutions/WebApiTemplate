using WebApiTemplate.Infrastructure;

namespace WebApiTemplate.Mocks {
    public class MockAuthentication : IWebApiTemplateAuthentication {
        public bool Authenticate(string username, string password) {
            //TODO: make a real implementation instead of using mock objects. :)
            return true;
        }
    }
}
