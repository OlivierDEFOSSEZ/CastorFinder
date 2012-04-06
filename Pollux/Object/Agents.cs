namespace Pollux.Object
{
    public class Agent
    {
        private string m_prenom;
        private int m_index;

        #region Propriétés
        public int Index
        {
            get { return m_index; }
            set { m_index = value; }
        }
        public string Prenom
        {
            get { return m_prenom; }
            set { m_prenom = value; }
        }
        #endregion
        public Agent(int index, string prenom)
        {
            m_index = index;
            m_prenom = prenom;
        }
        public override string ToString()
        {
            return m_prenom;
        }
    }
}
