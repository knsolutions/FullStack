import { render, screen, fireEvent, waitFor } from "@testing-library/react";
import { ExampleComponent } from "./ExampleComponent";
import { apiService } from "../services";

jest.mock("../services");

const mockedApiService = apiService as jest.Mocked<typeof apiService>;

describe("ExampleComponent", () => {
  beforeEach(() => {
    mockedApiService.setAuthToken.mockImplementation(() => {});
  });

  it("should fetch and display data on mount", async () => {
    const data = { id: 1, key: "value", value: "test" };
    mockedApiService.get.mockResolvedValue(data);

    render(<ExampleComponent />);

    await waitFor(() =>
      expect(mockedApiService.get).toHaveBeenCalledWith("/endpoint", {
        filter: "value",
      })
    );
    expect(screen.getByText(/test/i)).toBeInTheDocument();
  });

  it("should handle POST request", async () => {
    const data = { id: 1, key: "value", value: "test" };
    mockedApiService.post.mockResolvedValue(data);

    render(<ExampleComponent />);

    fireEvent.click(screen.getByText(/Post Data/i));

    await waitFor(() =>
      expect(mockedApiService.post).toHaveBeenCalledWith("/endpoint", {
        key: "value",
      })
    );
  });

  it("should handle PUT request", async () => {
    const data = { id: 1, key: "updatedValue", value: "test" };
    mockedApiService.put.mockResolvedValue(data);

    render(<ExampleComponent />);

    fireEvent.click(screen.getByText(/Put Data/i));

    await waitFor(() =>
      expect(mockedApiService.put).toHaveBeenCalledWith("/endpoint", 1, {
        key: "updatedValue",
      })
    );
  });

  it("should handle DELETE request", async () => {
    const data = { id: 1 };
    mockedApiService.delete.mockResolvedValue(data);

    render(<ExampleComponent />);

    fireEvent.click(screen.getByText(/Delete Data/i));

    await waitFor(() =>
      expect(mockedApiService.delete).toHaveBeenCalledWith("/endpoint", 1)
    );
  });
});
