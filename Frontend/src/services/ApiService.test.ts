import axios from "axios";
import { ApiService } from "./ApiService";
import { API_BASE_URL } from "../config";

jest.mock("axios");
const mockedAxios = axios as jest.Mocked<typeof axios>;

describe("ApiService", () => {
  let apiService: ApiService;

  beforeEach(() => {
    apiService = new ApiService(API_BASE_URL);
  });

  it("should perform a GET request", async () => {
    const data = { id: 1, key: "value" };
    mockedAxios.get.mockResolvedValue({ data });

    const result = await apiService.get("/endpoint");
    expect(result).toEqual(data);
    expect(mockedAxios.get).toHaveBeenCalledWith("/endpoint", { params: {} });
  });

  it("should perform a POST request", async () => {
    const data = { id: 1, key: "value" };
    mockedAxios.post.mockResolvedValue({ data });

    const result = await apiService.post("/endpoint", { key: "value" });
    expect(result).toEqual(data);
    expect(mockedAxios.post).toHaveBeenCalledWith("/endpoint", {
      key: "value",
    });
  });

  it("should perform a PUT request", async () => {
    const data = { id: 1, key: "updatedValue" };
    mockedAxios.put.mockResolvedValue({ data });

    const result = await apiService.put("/endpoint", 1, {
      key: "updatedValue",
    });
    expect(result).toEqual(data);
    expect(mockedAxios.put).toHaveBeenCalledWith("/endpoint/1", {
      key: "updatedValue",
    });
  });

  it("should perform a DELETE request", async () => {
    const data = { id: 1 };
    mockedAxios.delete.mockResolvedValue({ data });

    const result = await apiService.delete("/endpoint", 1);
    expect(result).toEqual(data);
    expect(mockedAxios.delete).toHaveBeenCalledWith("/endpoint/1");
  });
});
