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
        { //counter has kitchen object

            if (player.HasKitchenObject())
            { //player is carrying kitchen object

                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                { //Player is holding a Plate
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                }
                else
                { //Player is not carrying plate but something else
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject)) 
                    { //Counter is holding a plate
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO))
                        {
                            player.GetKitchenObject().DestroySelf();
                        }
                    }
                }
            }
            else
            {
                //player is not carrying kitchenObject
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
    
}
