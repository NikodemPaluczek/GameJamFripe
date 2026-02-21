using UnityEngine;

public interface INeons 
{

    bool CanPickUp { get; set; }
    public string NeonColor { get; set; }

    public void AcquireNeon();
    public void ActivateVisual();
    public void IncreaseEmission();

    public void ResetActivationAndEmission();
    public void PickUpNeon();
}
