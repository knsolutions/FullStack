import { CLIENT_ID } from "./config";
import { TENANT_ID } from "./config";
import { REDIRECT_URI } from "./config";


export const msalConfig = {
  auth: {
    clientId: CLIENT_ID,
    authority: TENANT_ID,
    redirectUri: REDIRECT_URI,
  },
  cache: {
    cacheLocation: "localStorage",
    storeAuthStateInCookie: false,
  },
};

export const loginRequest = {
  scopes: ["User.Read"],
};
