## Overview

Based on [Deep Learning With PyTorch - Full Course](https://www.youtube.com/watch?v=c36lUUr864M)

## Pytorch installation

- go to [Pytorch website](https://pytorch.org/) and select the combo specific to your system. Update the __requirements.txt__ file with the selected versions

- go to [NVidia CUDA Toolkit download page](https://developer.nvidia.com/cuda-toolkit-archive) and download the version of cuda, you selected above. Install it.

- check cuda was installed by running this command
    ```
    nvcc --version
    ```

```
python -m venv venv
venv\Scripts\activate
pip install -r requirements.txt
```