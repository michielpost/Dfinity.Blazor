import { AuthClient } from "@dfinity/auth-client";
import { canisterId, createActor, storage } from "../../declarations/storage";
import { ActorSubclass } from "@dfinity/agent";
import { _SERVICE } from "../../declarations/storage/storage.did";

let authClient: AuthClient;

const init = async () => {
  authClient = await AuthClient.create();
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

let storage_actor: ActorSubclass<_SERVICE>;

async function handleAuthenticated(authClient: AuthClient) {
  const identity = await authClient.getIdentity();
  storage_actor = createActor(canisterId as string, {
    agentOptions: {
      identity,
    },
  });

  console.log('login!');
}

init();

export function test() {
  console.log('test');
}

export async function write() {
  let name = 'a';
  let text = 'b';
  await storage.insert(name, text);
}

export async function get() {
  let d = await storage.lookup('a');
  console.log(d);
}

export async function writeUser() {
  let name = 'a';
  let text = 'buser';
  await storage_actor.insert(name, text);
}

export async function getUser() {
  let d = await storage_actor.lookup('a');
  console.log(d);
}

export async function logout() {
  await authClient.logout();      
  console.log('logout');
}

export async function whoami() {
  var r = await storage.whoami();      
  console.log(r);
}