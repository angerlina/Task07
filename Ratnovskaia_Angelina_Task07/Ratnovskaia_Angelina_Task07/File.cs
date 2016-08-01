

namespace Ratnovskaia_Angelina_Task07
{
    public class File : FileSystemItem
    {
        public File(string name) : base(name) { }

        public override FileSystemItem DeepCopy()
        {
            var other = (File)MemberwiseClone();
            other.Name = string.Copy(Name);
            return other;
        }
        
    }
}
