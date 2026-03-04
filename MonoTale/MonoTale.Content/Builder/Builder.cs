using Microsoft.Xna.Framework.Content.Pipeline;
using MonoGame.Framework.Content.Pipeline.Builder;

var contentCollectionArgs = new ContentBuilderParams()
{
    Mode = ContentBuilderMode.Builder,
    WorkingDirectory = $"{AppContext.BaseDirectory}../../../", // The Path to where your Content Folder can be located.
    SourceDirectory = "Assets", // Not actually needed as this is the default, but added for reference.
    Platform = TargetPlatform.DesktopGL
};

var builder = new Builder();

if (args != null && args.Length > 0)
{
    builder.Run(args);
}
else
{
    builder.Run(contentCollectionArgs);
}

return builder.FailedToBuild > 0 ? -1 : 0;

/// <summary>
/// Entry point for the Content Builder project, which when executed will build content according to the "Content Collection Strategy" defined in the Builder class.
/// </summary>
/// <remarks>
/// Make sure to validate the directory paths in the "ContentBuilderParams" for your specific project. For more details regarding the Content Builder, see the MonoGame documentation.
/// </remarks>
public class Builder : ContentBuilder
{
    public override IContentCollection GetContentCollection()
    {
        var contentCollection = new ContentCollection();

        // Include everything in the folder.
        contentCollection.Include<WildcardRule>("*");

        // By default, all content will be imported from the Assets folder using the default importer for their file type.
        // Please add any custom content collection rules here.
        return contentCollection;
    }
}