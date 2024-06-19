using System;

public interface IEditable
{
    public void SetController(WatchesController controller);

    public void ActivateEditMode();

    public void DectivateEditMode();

    public void OnEdited();

    public DateTime GetEditedTime();
}
