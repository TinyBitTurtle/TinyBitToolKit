namespace TinyBitTurtle.Toolkit
{
    public interface Core_Factory<O> where O : new()
    {
        O Create(Core_Template template);
    }
}