using Content.Shared.Traits.Assorted;
using Content.Shared.Chat;
using Content.Server.Chat.Systems;

namespace Content.Server.Traits.Assorted;

public sealed partial class SixSevenTriggerSystem : SharedSixSevenTriggerSystem
{
    [Dependency] private ChatSystem _chatSystem = default!;

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<EntitySpokeEvent>(OnEntitySpoke);
    }

    private void OnEntitySpoke(EntitySpokeEvent ev)
    {
        if (!HasComp<SixSevenTriggerComponent>(ev.Source))
            return;

        if (ev.Message.Contains("67") || ev.Message.ToLower().Contains("sixty seven"))
        {
            _chatSystem.TrySendInGameICMessage(ev.Source, "SIX SEVEN!!!", InGameICChatType.Speak, false);
        }
    }
}
