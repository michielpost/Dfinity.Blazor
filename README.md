# Dfinity.Blazor
Blazor library to work with Dfinity Internet Computer. Use this library to easily integrate login with Internet Identity in your Blazor WebAssembly app. This library can also be used to communicate with Internet Computer canisters.

Deployed to https://syisf-7qaaa-aaaah-aauda-cai.ic0.app/

Available on NuGet: https://www.nuget.org/packages/Dfinity.Blazor/

## Features
- Login with Internet Identity
- Get Current Internet Identity
- Store and Get key/value pairs
- Store and Get key/value pairs for a logged in user


## Demo
- Install the Dfinity SDK from https://smartcontracts.org
- Install the .Net SDK from https://get.dot.net
- Clone this code to your local PC

1. Publish the sample app:
```ps
dotnet publish src/Dfinity.Blazor.SampleApp -c Release
```

2. Start a local internet computer.

   ```text
   dfx start
   ```

3. Open a new terminal window.

4. Reserve an identifier for your canister.

   ```text
   dfx canister create --all
   ```

5. Install frontend dependencies

   ```text
   npm install
   ```

6. Build the canisters

   ```text
   dfx build
   ```

7. Deploy the canisters

   ```text
   dfx canister install --all
   ```

8. Take note of the URL at which the canister is accessible.

   ```text
   echo "http://localhost:8000/?canisterId=$(dfx canister id www)"
   ```

9. Open the URL in your web browser.


## How to use this in your own app
Example implementation can be found at https://github.com/michielpost/SkyDocs/tree/feature/dfinity

Steps:
- Install this library from NuGet [Dfinity.Blazor](https://www.nuget.org/packages/Dfinity.Blazor/)
- Create a folder for your storage canister and add Main.mo
- Add your storage canister to dfx.json

```json
 "storage": {
      "main": "src/storage/main.mo",
      "type": "motoko"
    },
```

- Add index.js and index.html to your www/asset canister
- Add package.json to the root of your project
- Follow the steps to run the demo to build your own project
- Make sure the compiled/minified index.js end up in the `wwwroot` of your Blazor app.
- Include the js file in your html:
```html
 <script defer src="index.js"></script>
```

### Inspiration
- https://github.com/krpeacock/auth-client-demo/
- https://github.com/dfinity/examples/tree/master/motoko/phone-book
- https://github.com/dfinity/examples/tree/master/motoko/superheroes