using UnityEngine;

public class ClearCounter : BaseCounter
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;    

    public override void Interact(Player player)
    {
        if (!HasKitchenObject()) 
        {
            //Counter has no kitchen object
            if (player.HasKitchenObject())
            {
                //Player is carrying kitchen object
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
        }
        else
        {
            //counter has kitchen object
            if (player.HasKitchenObject()) 
            {
                //player is carrying kitchen object
            }
            else
            {
                //player is not carrying kitchenObject
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
    
}
