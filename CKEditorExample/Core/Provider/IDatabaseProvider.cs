using System;

namespace CKEditorExample.Core.Provider
{
    public interface IDatabaseProvider
    {
        dynamic GetDb();
    }
}