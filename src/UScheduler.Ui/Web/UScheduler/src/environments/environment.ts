import authConfig from "../../auth-config.json"

export const environment = {
  production: false,
  apiEndpoint: "",
  auth: {
    domain: authConfig.domain,
    clientId: authConfig.clientId,
    redirectUri: window.location.origin,
    audience: authConfig.audience
  }
};
