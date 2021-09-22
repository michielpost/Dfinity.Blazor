import { AuthClient } from "@dfinity/auth-client";
import { renderLoggedIn } from "./views/loggedIn";
import { canisterId, createActor, storage } from "../../declarations/storage";

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

export function test() {
  console.log('test');
}

export async function write() {
  let name = 'a';
  let desc = 'b';
  let phone = 'c';
  await storage.insert(name, { desc, phone });
}

export async function get() {
  let d = await storage.lookup('a');
  console.log(d);
}
