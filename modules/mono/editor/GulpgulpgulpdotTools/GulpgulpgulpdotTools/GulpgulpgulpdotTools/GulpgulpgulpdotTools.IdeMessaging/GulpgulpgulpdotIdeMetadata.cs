using System.Diagnostics.CodeAnalysis;

namespace GulpgulpgulpdotTools.IdeMessaging
{
    public readonly struct GulpgulpgulpdotIdeMetadata
    {
        public int Port { get; }
        public string EditorExecutablePath { get; }

        public const string DefaultFileName = "ide_messaging_meta.txt";

        public GulpgulpgulpdotIdeMetadata(int port, string editorExecutablePath)
        {
            Port = port;
            EditorExecutablePath = editorExecutablePath;
        }

        public static bool operator ==(GulpgulpgulpdotIdeMetadata a, GulpgulpgulpdotIdeMetadata b)
        {
            return a.Port == b.Port && a.EditorExecutablePath == b.EditorExecutablePath;
        }

        public static bool operator !=(GulpgulpgulpdotIdeMetadata a, GulpgulpgulpdotIdeMetadata b)
        {
            return !(a == b);
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            return obj is GulpgulpgulpdotIdeMetadata metadata && metadata == this;
        }

        public bool Equals(GulpgulpgulpdotIdeMetadata other)
        {
            return Port == other.Port && EditorExecutablePath == other.EditorExecutablePath;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Port * 397) ^ (EditorExecutablePath != null ? EditorExecutablePath.GetHashCode() : 0);
            }
        }
    }
}
