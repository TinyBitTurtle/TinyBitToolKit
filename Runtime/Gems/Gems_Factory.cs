namespace TinyBitTurtle.Toolkit
{
    public class Gems_Factory : Core_Factory<Core_IObject>
    {
        public Core_IObject Create(Core_Template template)
        {
            Core_IObject newObject = default;

            switch (template)
            {
                case AudioSettings.AudioTemplate:
                newObject = (Core_IObject)new AudioCtrl<AudioCtrl>.AudioObject(); // use a pool for audioObject instantiation
                //newObject.audioSource = newObject.AddComponent<AudioSource>();
                //newObject.audioSource.volume = audioTemplate.volume;  
                //newObject.audioSource.loop = audioTemplate.audioType == AudioSettings.AudioTemplate.AudioType.music ? true : false;
                    break;

                default:
                    newObject = default;
                    break;
            }
            return newObject;
        }
    }
}