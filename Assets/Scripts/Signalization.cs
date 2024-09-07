using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signalization : MonoBehaviour
{
    [SerializeField] private InHomeArea inHomeArea;
    [SerializeField] private float _speed = 3f;

    private AudioSource _audioSource;
    private Coroutine _volumeChangeJob;
    private int _targetVolume;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _audioSource.volume = 0;
        _targetVolume = 0;
    }

    private void OnEnable()
    {
        inHomeArea.Entered += IncreaseVolume;
        inHomeArea.Abonded += DecreaseVolume;
    }

    private void OnDisable()
    {
        inHomeArea.Entered -= IncreaseVolume;
        inHomeArea.Abonded -= DecreaseVolume;
    }

    private IEnumerator ChangeVolume(float target)
    {
        while (_audioSource.volume != target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, _speed * Time.deltaTime);

            yield return null;
        }
    }

    private void IncreaseVolume()
    {
        if (_volumeChangeJob != null)
            StopCoroutine(_volumeChangeJob);

        _audioSource.Play();

        _targetVolume = 1;
        _volumeChangeJob = StartCoroutine(ChangeVolume(_targetVolume));
    }

    private void DecreaseVolume()
    {
        if (_volumeChangeJob != null)
            StopCoroutine(_volumeChangeJob);

        _targetVolume = 0;
        _volumeChangeJob = StartCoroutine(ChangeVolume(_targetVolume));
    }
}