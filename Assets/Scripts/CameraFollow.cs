using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject m_target;
    [SerializeField]
    private bool m_firstPerson = true;
    private void Update()
    {
        if (m_target == null)
        {
            m_target = GameObject.FindGameObjectWithTag("CameraTarget");
        }

        if (m_firstPerson)
        {
            FirstPerson();
        }
        else
        {
            ThirdPerson();
        }
    }

    void FirstPerson()
    {
        gameObject.transform.position = m_target.transform.position;
    }

    void ThirdPerson()
    {
        // Implementation for third-person camera logic
    }
}
