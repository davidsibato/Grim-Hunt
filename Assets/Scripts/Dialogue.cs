using UnityEngine;

[CreateAssetMenu (fileName = " New Dialogue" , menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
    [SerializeField] string[] m_enemyDialogue;

    public string GetCurrentLine(int index)
    {
        return m_enemyDialogue[index];
    }

    public int GetArrayLength()
    {
        return m_enemyDialogue.Length;
    }
  
}
