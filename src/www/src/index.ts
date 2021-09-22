import { AuthClient } from "@dfinity/auth-client";
import { renderLoggedIn } from "./views/loggedIn";
import { canisterId, createActor } from "../../declarations/storage";

const init = async () => {
  const authClient = await AuthClient.create();
  if (await authClient.isAuthenticated()) {
    handleAuthenticated(authClient);
  }

  const loginButton = document.getElementById(
    "loginButton"
  ) as HTMLButtonElement;
  loginButton.onclick = async () => {
    await authClient.login({
      onSuccess: async () => {
        handleAuthenticated(authClient);
      },
      identityProvider:
        process.env.DFX_NETWORK === "ic"
          ? "https://identity.ic0.app/#authorize"
          : process.env.LOCAL_II_CANISTER,
    });
  };
};

async function handleAuthenticated(authClient: AuthClient) {
  const identity = await authClient.getIdentity();
  const storage_actor = createActor(canisterId as string, {
    agentOptions: {
      identity,
    },
  });

  renderLoggedIn(storage_actor, authClient);
}

init();
