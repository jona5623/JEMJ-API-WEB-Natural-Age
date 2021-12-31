using System;
using System.Reflection;

namespace JEMJ_API_WEB_Natural_Age.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}