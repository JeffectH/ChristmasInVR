using UnityEngine;

public class ChristmasDecoration : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] private float _speedMove = 1f;
    [SerializeField] private float _speedRotation = 2f;
    [SerializeField] private float _minValueToMoveToy = 0.4f;
    [SerializeField] private float _minValueToStopMove = 0.01f;
    [SerializeField] private bool _isChristmasDecorationOn = true;

    private void Update()
    {
        MoveChristamsDecoration();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.GetComponent<HandRight>())
            _isChristmasDecorationOn = true;
    }

    private void MoveChristamsDecoration()
    {
        if (_isChristmasDecorationOn)
        {
            if (Vector3.Distance(transform.position, _point.transform.position) < _minValueToMoveToy)
            {
                //возможна ошибка на null
                GetComponent<Rigidbody>().isKinematic = true;
                _point.GetComponent<MeshRenderer>().enabled = false;

                if (_point.childCount > 0)
                    for (int i = 0; i < _point.childCount; i++)
                        if (_point.GetChild(i).GetComponent<MeshRenderer>())
                            _point.GetChild(i).GetComponent<MeshRenderer>().enabled = false;

                MagnitDecoration(_point);

                if (Vector3.Distance(transform.position, _point.transform.position) < _minValueToStopMove)
                {
                    Salut.instance.UpdateActiveDecorationToys();
                    _isChristmasDecorationOn = false;
                }
            }
        }
    }

    private void MagnitDecoration(Transform point)
    {
        transform.position = Vector3.Lerp(transform.position, point.position, Time.deltaTime * _speedMove);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, point.rotation, _speedRotation);
    }
}
