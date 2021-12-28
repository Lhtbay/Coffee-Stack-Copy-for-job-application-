using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds_Manager_sc : MonoBehaviour
{
    [Header("All Audios")]
    [SerializeField] private AudioSource _awardsAudio;
    [SerializeField] private AudioSource _lidClosedAudio;
    [SerializeField] private AudioSource _takeHandAudio;
    [SerializeField] private AudioSource _takeCupAudio;
    [SerializeField] private AudioSource _sleveeAudio;
    [SerializeField] private AudioSource _sellAudio;
    [SerializeField] private AudioClip[] _allSounds;

    private AudioSource _audioSounds;

    private void Start()
    {
        _audioSounds = gameObject.GetComponent<AudioSource>();

        _awardsAudio.clip = _allSounds[0];
        _lidClosedAudio.clip = _allSounds[2];
        _takeHandAudio.clip = _allSounds[3];
        _takeCupAudio.clip = _allSounds[4];
        _sleveeAudio.clip = _allSounds[1];
        _sellAudio.clip = _allSounds[5];
    }

    public void AwardsSounds()
    {
        _awardsAudio.Play();
    }
    public void LidClosedSounds()
    {
        _lidClosedAudio.Play();
    }
    public void TakeHandSounds()
    {
        _takeHandAudio.Play();
    }
    public void TakeCupSounds()
    {
        _takeCupAudio.Play();
    }
    public void SleveeSounds()
    {
        _sleveeAudio.Play();
    }
    public void SellSounds()
    {
        _sellAudio.Play();
    }
}
