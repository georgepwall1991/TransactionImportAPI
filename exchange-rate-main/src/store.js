import { act } from "react-dom/cjs/react-dom-test-utils.production.min";
import { createStore } from "redux";

const initialState = {
  amount: "12:00",
  currencyCode: "USD",
};

function reducer(state = initialState, action) {
  switch (action.type) {
    case "amountChanged":
      return { ...state, amount: action.payload };
    case "currencyCodeChange":
      return { ...state, currencyCode: action.payload };
    default:
      return state;
  }
  return state;
}

export const store = createStore(reducer);
